﻿using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Database.Entities.Pupils
{
    public sealed class PupilDb
    {
        /// <summary>
        /// Gets or sets id if pupil.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of pupil.
        /// </summary>
        [MaxLength(64)] 
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets surname of pupil.
        /// </summary>
        [MaxLength(64)] 
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets birthdate of pupil.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets gender of pupil.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets phone number of pupil.
        /// </summary>
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets address of pupil.
        /// </summary>
        [MaxLength(128)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city, where pupil lives.
        /// </summary>
        [MaxLength(64)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a name of school, where pupil study.
        /// </summary>
        [MaxLength(128)]
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets grade of study of pupil.
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the language of education.
        /// </summary>
        public CourseLanguage CourseLanguage { get; set; }

        /// <summary>
        /// Gets or sets the shift of study.
        /// </summary>
        public Shift Shift { get; set; }
    }
}
