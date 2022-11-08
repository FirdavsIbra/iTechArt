﻿using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.Text.Json.Serialization;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IStudent
    {
        /// <summary>
        /// Gets Id of business model entities
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets First name of student
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets Last name of student
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets Email of student
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets Password of student
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets String value majority, field of study
        /// </summary>
        public string Majority { get; }

        /// <summary>
        /// Gets boolean Gender entity of student
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets Birthday of student
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; }

        /// <summary>
        /// Gets Name of university of student
        /// </summary>
        public string University { get; }
    }
}
