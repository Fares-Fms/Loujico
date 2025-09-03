using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loujico.Models;

public partial class TbEmployee
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الاسم الأول مطلوب")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "الاسم الأول يجب أن يكون بين 2 و 50 حرف")]
    [RegularExpression(@"^[\p{L}\s\-]+$", ErrorMessage = "الاسم الأول يجب أن يحتوي على أحرف ومسافات وشرطات فقط")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "اسم العائلة مطلوب")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "اسم العائلة يجب أن يكون بين 2 و 50 حرف")]
    [RegularExpression(@"^[\p{L}\s\-]+$", ErrorMessage = "اسم العائلة يجب أن يحتوي على أحرف ومسافات وشرطات فقط")]
    public string LastName { get; set; } = null!;
    [Required(ErrorMessage = "رقم الهاتف مطلوب")]
    [RegularExpression(@"^[0-9+\-\s]{6,20}$", ErrorMessage = "رقم الهاتف غير صالح")]
    [StringLength(20, ErrorMessage = "رقم الهاتف يجب ألا يتجاوز 20 خانة")]
    public string Phone { get; set; } = null!;
    [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
    [StringLength(150, ErrorMessage = "البريد الإلكتروني يجب ألا يتجاوز 150 خانة")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "عنوان الموظف مطلوب")]
    [StringLength(255, ErrorMessage = "عنوان الموظف يجب ألا يتجاوز 255 خانة")]
    public string? EmployeesAddress { get; set; }
    [Required(ErrorMessage = "المسمى الوظيفي مطلوب")]
    [StringLength(100, ErrorMessage = "المسمى الوظيفي يجب ألا يتجاوز 100 خانة")]
    public string? Position { get; set; }
    [Required(ErrorMessage = "العمر مطلوب")]
    [Range(18, 70, ErrorMessage = "العمر يجب أن يكون بين 18 و 70 سنة")]
    public int Age { get; set; }

    public string? ProfileImage { get; set; }

    public bool IsPresent { get; set; }
    [StringLength(1000, ErrorMessage = "الوصف يجب ألا يتجاوز 1000 خانة")]
    public string? EmployeesDescription { get; set; }
    [Range(1, 3650, ErrorMessage = "مدة الخدمة يجب أن تكون بين 1 و 3650 يوم")]
    public int? ServiceDuration { get; set; }
    [Range(0, 1000000, ErrorMessage = "الراتب يجب أن يكون بين 0 و 1,000,000")]
    public decimal? Salary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastVisit { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<TbProductsEmployee>? TbProductsEmployees { get; set; } = new List<TbProductsEmployee>();

    public virtual ICollection<TbProjectsEmployee>? TbProjectsEmployees { get; set; } = new List<TbProjectsEmployee>();
}
