// <copyright file="StartRequestExamTestModel.cs" username="Krzysztof Maraszkiewicz">
//     Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Properties;

namespace DataModel.Models.WebAPI
{
    public class StartRequestExamTestModel
    {
        /// <summary>
        /// Gets or sets the known language type identifier.
        /// </summary>
        /// <value>
        /// The known language type identifier.
        /// </value>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int KnownLanguageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the learning language type identifier.
        /// </summary>
        /// <value>
        /// The learning language type identifier.
        /// </value>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int LearningLanguageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the length of the words.
        /// </summary>
        /// <value>
        /// The length of the words.
        /// </value>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int WordsLength { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartRequestExamTestModel"/> class.
        /// </summary>
        public StartRequestExamTestModel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartRequestExamTestModel"/> class.
        /// </summary>
        /// <param name="knownLanguageTypeId">The known language type identifier.</param>
        /// <param name="learningLanguageTypeId">The learning language type identifier.</param>
        /// <param name="wordsLength">Length of the words.</param>
        public StartRequestExamTestModel(int knownLanguageTypeId, int learningLanguageTypeId, int wordsLength)
        {
            KnownLanguageTypeId = knownLanguageTypeId;
            LearningLanguageTypeId = learningLanguageTypeId;
            WordsLength = wordsLength;
        }
    }
}