﻿namespace HA.LightningService.ConBeeConnector.Interfaces;

public interface IAccessToken
{
    Task<string> GetAccessToken();
}