using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models;


public class Todo
{
    [Key]
    public int Id { get; set; }

    public string title { get; set; }

    public string estimatedTime { get; set; }

    public string category { get; set; }
    public int status { get; set; } = 0;// 0 = To Do, 1 = Doing, 2 = Done

    public DateTime dueDate { get; set; }

    [ForeignKey(nameof(User))]
    public int userId { get; set; }
    public User user { get; set; }

    [ForeignKey(nameof(Importance))]
    public int ImportanceId { get; set; }
    public Importance importance { get; set; }


}
