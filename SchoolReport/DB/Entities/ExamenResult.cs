﻿using System.ComponentModel.DataAnnotations;

namespace SchoolReport.DB.Entities
{
    //ToDo: Implement mapping in separate class????
    public class ExamenResult
    {
        [Key]
        public int ExamenResultId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int Score { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }
    }
}