using InterviewSample2.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSample2.Application.Contracts;

public interface IUrlRepository
{
    void Add(UrlInfo url);
    void Update(UrlInfo url);
    UrlInfo Get(string link);
}
