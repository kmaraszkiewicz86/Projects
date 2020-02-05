// <copyright file="IExamTestService.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;

namespace Interfaces.ExamTestMgt
{
    public interface IExamTestService
    {
        /// <summary>
        /// Randoms the words.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Exam words for test</returns>
        Task<ExamTest> RandomWords(StartRequestExamTestModel model);

        /// <summary>
        /// Sets the word status.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return void data</returns>
        Task SetWordStatus(SetWordStatusModel model);
    }
}