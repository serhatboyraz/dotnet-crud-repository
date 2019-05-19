using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CrudRepositoryExample.Data.Enum;

namespace CrudRepositoryExample.Data.Model
{
    [Table("project")]
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }

        public ProjectStatusEnum Status { get; set; }

    }
}
