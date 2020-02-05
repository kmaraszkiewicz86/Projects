// <copyright file="ExamTestWord.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.DbModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ExamTestWord
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the exam test identifier.
        /// </summary>
        /// <value>
        /// The exam test identifier.
        /// </value>
        [Required]
        public int ExamTestId { get; set; }

        /// <summary>
        /// Gets or sets the exam test.
        /// </summary>
        /// <value>
        /// The exam test.
        /// </value>
        public ExamTest ExamTest { get; set; }

        /// <summary>
        /// Gets or sets the word identifier.
        /// </summary>
        /// <value>
        /// The word identifier.
        /// </value>
        [Required]
        public int WordId { get; set; }

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        public Word Word { get; set; }
    }
}