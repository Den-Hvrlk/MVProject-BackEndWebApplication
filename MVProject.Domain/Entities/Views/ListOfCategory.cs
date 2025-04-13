using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ListOfCategory
{
    public string ID_Category { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;
}
