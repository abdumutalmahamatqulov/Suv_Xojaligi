﻿using Microsoft.AspNetCore.Identity;

namespace Suv_Xojaligi.V1.Auth.Models;

public class RoleModel
{
    public virtual Guid Id { get; set; }

    public virtual string? Name { get; set; }
    public RoleModel MapFromEntity(IdentityRole<Guid> role)
    {
        Id = role.Id;
        Name = role.Name;
        return this;
    }
}