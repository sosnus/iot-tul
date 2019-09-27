function Decoder(bytes, port) {
    // Decode an uplink message from a buffer
    // (array) of bytes to an object of fields.
    var i = 4;

    var latitude = (bytes[i + 2] << 16) | (bytes[i + 3] << 8) | bytes[i + 04];
    var longitude = (bytes[i + 5] << 16) | (bytes[i + 6] << 8) | bytes[i + 07];
    var altitude = (bytes[i + 8] << 16) | (bytes[i + 9] << 8) | bytes[i + 10];
    
    var msb = 0x800000;
    if (longitude & msb) longitude -= msb << 1;
    if (latitude & msb) latitude -= msb << 1;
    if (altitude & msb) altitude -= msb << 1;

    var decoded = {
        latitude: latitude / 10000,
        longitude: longitude / 10000,
        altitude: altitude / 100
    };

    // if (port === 1) decoded.led = bytes[0];

    return decoded;
}
