// <copyright file="SetWordStatusModel.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Properties;

namespace DataModel.Models.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class SetWordStatusModel
    {
        /// <summary>
        /// Gets or sets the exam test identifier.
        /// </summary>
        /// <value>
        /// The exam test identifier.
        /// </value>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int ExamTestId { get; set; }

        /// <summary>
        /// Gets or sets the word identifier.
        /// </summary>
        /// <value>
        /// The word identifier.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int WordId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [was proper ansewer].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [was proper ansewer]; otherwise, <c>false</c>.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public bool WasProperAnsewer { get; set; }
    }
}