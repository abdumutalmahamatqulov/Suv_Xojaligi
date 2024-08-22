﻿using Suv_Xojaligi.Data.Entities.Commons;

namespace Suv_Xojaligi.Data.Entities.News;

public class New : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public Guid? ImageId { get; set; }
    public FileMetadata ImageUrl { get; set; }
    public DateOnly  DateTime { get; set; }
}
