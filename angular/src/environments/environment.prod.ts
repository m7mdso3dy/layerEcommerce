import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44319/',
  redirectUri: baseUrl,
  clientId: 'layerEcommerce_App',
  responseType: 'code',
  scope: 'offline_access layerEcommerce',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'layerEcommerce',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44319',
      rootNamespace: 'layerEcommerce',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
