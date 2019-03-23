
function Decoder(bytes, port) {
  // Decode an uplink message from a buffer
  // (array) of bytes to an object of fields.
  var decoded = {sensorID:"",sensorPassword:"",Value:""};
  var flag=0;
  for (i=0;i<8;i++)
  {
    if ((String.fromCharCode(bytes[i]) != "0") || flag==1)
    {
      decoded.sensorID += String.fromCharCode(bytes[i]);
      flag=1;
    }
  }
  
  for (i=0;i<8;i++)
  {
    if (String.fromCharCode(bytes[8+i]) != "0")
    {
      decoded.sensorPassword += String.fromCharCode(bytes[8+i]);
    }
  }
  
  var flaga=0;
  
  for (i=0;i<16;i++)
  {
    if ((String.fromCharCode(bytes[16+i]) != "0") | (flaga === 1))
    {
      decoded.Value += String.fromCharCode(bytes[16+i]);
      // TODO: (String)  decoded.Value(HEX) convert to double, and write as string, mean 40355EB851EB851F(HEX)=21.37(Double)
      flaga=1;
    }
    
  }

  return decoded;
}
