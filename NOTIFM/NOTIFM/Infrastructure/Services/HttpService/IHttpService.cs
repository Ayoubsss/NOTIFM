using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NOTIFM.Infrastructure.Services.RestService
{
    public interface IHttpService
    {
        Task<M> PostHttpJsonRequest<R, M>(string apiUrl, R reqModel);
    }
}
