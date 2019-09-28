# ttnExampleCodeToArduinoArrays

How to convert code from `https://console.thethingsnetwork.org/applications/<app-name>/devices/<device-name>` into arduino arrays?

Before:
```javascript
const char *devAddr = "26011796";
const char *nwkSKey = "2E1803102333C362404805A5E58E1B3F";
const char *appSKey = "7F88D4A710B477B979ADCB95AFD4F43B";
```
After:
```c
// LoRaWAN NwkSKey, network session key
// This is the default Semtech key, which is used by the early prototype TTN
// network.
static const PROGMEM u1_t NWKSKEY[16] = { 0x2E, 0x18, 0x03, 0x10, 0x23, 0x33, 0xC3, 0x62, 0x40, 0x48, 0x05, 0xA5, 0xE5, 0x8E, 0x1B, 0x3F };

// LoRaWAN AppSKey, application session key
// This is the default Semtech key, which is used by the early prototype TTN
// network.
static const u1_t PROGMEM APPSKEY[16] = { 0x7F, 0x88, 0xD4, 0xA7, 0x10, 0xB4, 0x77, 0xB9, 0x79, 0xAD, 0xCB, 0x95, 0xAF, 0xD4, 0xF4, 0x3B };

// LoRaWAN end-device address (DevAddr)
static const u4_t DEVADDR = 0x26011796 ; // <-- Change this address for every node!

```

After and clean:
```c
static const PROGMEM u1_t NWKSKEY[16] = { 0x2E, 0x18, 0x03, 0x10, 0x23, 0x33, 0xC3, 0x62, 0x40, 0x48, 0x05, 0xA5, 0xE5, 0x8E, 0x1B, 0x3F };

static const u1_t PROGMEM APPSKEY[16] = { 0x7F, 0x88, 0xD4, 0xA7, 0x10, 0xB4, 0x77, 0xB9, 0x79, 0xAD, 0xCB, 0x95, 0xAF, 0xD4, 0xF4, 0x3B };

static const u4_t DEVADDR = 0x26011796 ; // <-- Change this address for every node!

```
