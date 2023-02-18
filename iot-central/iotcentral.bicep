resource symbolicname 'Microsoft.IoTCentral/iotApps@2021-11-01-preview' = {
  name: 'string'
  location: 'string'
  tags: {
    tagName1: 'tagValue1'
    tagName2: 'tagValue2'
  }
  sku: {
    name: 'string'
  }
  identity: {
    type: 'string'
  }
  properties: {
    displayName: 'string'
    networkRuleSets: {
      applyToDevices: bool
      applyToIoTCentral: bool
      defaultAction: 'string'
      ipRules: [
        {
          filterName: 'string'
          ipMask: 'string'
        }
      ]
    }
    publicNetworkAccess: 'string'
    subdomain: 'string'
    template: 'string'
  }
}
