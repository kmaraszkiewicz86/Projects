// <copyright file="ExamTestController.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.WebAPI;
using Interfaces.ExamTestMgt;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseController" />
    [Produces("application/json")]
    [Route("api/ExamTest")]
    public class ExamTestController : BaseController
    {
        /// <summary>
        /// The exam test service
        /// </summary>
        private readonly IExamTestService _examTestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamTestController"/> class.
        /// </summary>
        /// <param name="examTestService">The exam test service.</param>
        public ExamTestController(IExamTestService examTestService)
        {
            _examTestService = examTestService;
        }

        /// <summary>
        /// Randoms the words.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("RandomWords")]
        public async Task<IActionResult> RandomWords([FromBody] StartRequestExamTestModel model)
        {
            return await OnActionWorkAsync(async () =>
                new ObjectResult(await _examTestService.RandomWords(model)));
        }

        /// <summary>
        /// Sets the word status.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("SetWordStatus")]
        public async Task<IActionResult> SetWordStatus([FromBody] SetWordStatusModel model)
        {
            return await OnActionWorkAsync(async () =>
            {
                await _examTestService.SetWordStatus(model);
                return Ok("ok");
            });
        }
    }
}