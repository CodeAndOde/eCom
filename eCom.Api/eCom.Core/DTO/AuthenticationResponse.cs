﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Core.DTO;

public record AuthenticationResponse
(Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
)
{
    public AuthenticationResponse() : this(default, default, default, default, default, default){}

}

