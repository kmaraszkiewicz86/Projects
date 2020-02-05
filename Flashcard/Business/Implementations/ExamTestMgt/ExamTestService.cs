// <copyright file="ExamTestService.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Implementations.Models;
using Interfaces.ExamTestMgt;
using Interfaces.WordMgt;
using Microsoft.EntityFrameworkCore;

namespace Implementations.ExamTestMgt
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IExamTestService" />
    public class ExamTestService : IExamTestService
    {
        /// <summary>
        ///     The flashcard database context
        /// </summary>
        private readonly FlashcardDbContext _flashcardDbContext;

        /// <summary>
        /// The word service
        /// </summary>
        private readonly IWordService _wordService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamTestService"/> class.
        /// </summary>
        /// <param name="flashcardDbContext">The flashcard database context.</param>
        public ExamTestService(FlashcardDbContext flashcardDbContext, IWordService wordService)
        {
            _flashcardDbContext = flashcardDbContext;
            _wordService = wordService;
        }

        /// <summary>
        /// Randoms the words.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Exam words for test
        /// </returns>
        public async Task<ExamTest> RandomWords(StartRequestExamTestModel model)
        {
            var knownLanguageType =
                await _flashcardDbContext.LanguageTypes.FirstOrDefaultAsync(l => l.Id == model.KnownLanguageTypeId);

            if (knownLanguageType == null)
                throw new NotFoundException("Known language type not found");

            var learningLanguageType =
                await _flashcardDbContext.LanguageTypes.FirstOrDefaultAsync(l => l.Id == model.LearningLanguageTypeId);

            if (learningLanguageType == null)
                throw new NotFoundException("Learning language type not found");

            var examTest = new ExamTest
            {
                KnownLanguageType = knownLanguageType,
                LearningLanguageType = learningLanguageType,
                Created = DateTime.Now
            };

            using (var transaction = _flashcardDbContext.Database.BeginTransaction())
            {
                try
                {
                    await _flashcardDbContext.ExamTests.AddAsync(examTest);
                    
                    var examTestWords = (await _wordService.GetRandomWords(model.CategoryId, model.WordsLength))?.Select(w => new ExamTestWord
                    {
                        ExamTest = examTest,
                        Word = w
                    }) ?? new List<ExamTestWord>();

                    if (!examTestWords.Any())
                    {
                        throw new BadRequestException("No words to fetch");
                    }

                    await _flashcardDbContext.ExamTestWords.AddRangeAsync(examTestWords);

                    _flashcardDbContext.SaveChanges();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            
            return examTest;
        }

        /// <summary>
        /// Sets the word status.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// return void data
        /// </returns>
        public async Task SetWordStatus(SetWordStatusModel model)
        {
            _flashcardDbContext.ExamTests.Include(e => e.WordAnswerWords).ThenInclude(w => w.WordAnswer);

            var examTest = await _flashcardDbContext.ExamTests.FirstOrDefaultAsync(e => e.Id == model.ExamTestId);

            if (examTest == null)
                throw new NotFoundException("ExamTest not found");

            var wordAnswerWords = examTest?.WordAnswerWords.FirstOrDefault(w => w.WordId == model.WordId);
            
            if (wordAnswerWords == null)
                throw new NotFoundException("Word of exam test not found");

            wordAnswerWords.WordAnswer.IsValidAnswer = model.WasProperAnsewer;

            _flashcardDbContext.Update(wordAnswerWords);

            _flashcardDbContext.SaveChanges();
        }
    }
}