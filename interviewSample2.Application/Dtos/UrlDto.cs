using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interviewSample2.Application.Dtos;

public sealed record UrlDto(
    string url, 
    int views);
