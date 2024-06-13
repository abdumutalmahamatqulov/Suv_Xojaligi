﻿namespace Suv_Xojaligi.Data.Entities;

public class FileMetadata
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
