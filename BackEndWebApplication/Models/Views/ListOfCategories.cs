using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfCategories
{
    public string IdCategory { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;
}
