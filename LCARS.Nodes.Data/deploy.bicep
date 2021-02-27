param appName string = 'uss${uniqueString(resourceGroup().id)}'
param location string = resourceGroup().location

resource webApp 'Microsoft.Web/sites@2020-06-01'  = {
  name: appName
  location: location
}