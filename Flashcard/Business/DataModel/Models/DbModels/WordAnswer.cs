// <copyright file="WordAnswer.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.DbModels
{
    public class WordAnswer
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid answer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid answer; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool IsValidAnswer { get; set; }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        [Required]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the word answer words.
        /// </summary>
        /// <value>
        /// The word answer words.
        /// </value>
        public ICollection<WordAnswerWord> WordAnswerWords { get; set; }
    }
}