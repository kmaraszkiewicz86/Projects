// <copyright file="ExamTest.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.DbModels
{
    public class ExamTest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the known language type identifier.
        /// </summary>
        /// <value>
        /// The known language type identifier.
        /// </value>
        [Required]
        [ForeignKey("LanguageType")]
        public int KnownLanguageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the known language.
        /// </summary>
        /// <value>
        /// The type of the known language.
        /// </value>
        public LanguageType KnownLanguageType { get; set; }

        /// <summary>
        /// Gets or sets the learning language type identifier.
        /// </summary>
        /// <value>
        /// The learning language type identifier.
        /// </value>
        [Required]
        [ForeignKey("LanguageType")]
        public int LearningLanguageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the learning language.
        /// </summary>
        /// <value>
        /// The type of the learning language.
        /// </value>
        public LanguageType LearningLanguageType { get; set; }

        /// <summary>
        /// The exam test words
        /// </summary>
        public ICollection<ExamTestWord> ExamTestWords;

        /// <summary>
        /// The word answer words
        /// </summary>
        public ICollection<WordAnswerWord> WordAnswerWords;

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>
        /// The updated.
        /// </value>
        public DateTime Updated { get; set; }
    }
}