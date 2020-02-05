// <copyright file="WordHelper.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Implementations.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class WordHelper
    {
        /// <summary>
        /// Includes the exam test joins.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <returns></returns>
        public static IIncludableQueryable<Word, ExamTest> IncludeExamTestJoins(this DbSet<Word> words)
        {
            return words.Include(w => w.CategoriesWord)
                .Include(w => w.WordAnswerWords)
                .ThenInclude(w => w.ExamTest);
        }
    }
}