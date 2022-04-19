using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.LightningService.ConBeeConnector.Interfaces;

public interface IAccessToken
{
    Task<string> GetAccessToken();
}