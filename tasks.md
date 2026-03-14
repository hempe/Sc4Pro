# Hardware Testing Tasks

## Units
- [ ] What does DS1 content[3] (d[5]) value mean? Real app sends `0x04` — confirm if `0x04` = yards, and what value = metric
- [ ] Press the UNIT button on the remote — capture the button number and what packet(s) the device sends back
- [ ] After pressing UNIT, does the device display change? Does it send a DS1 ack or an unsolicited packet?

## Remote button numbers (unknown)
- [ ] MODE button — capture button number
- [ ] LANG button — capture button number
- [ ] VOL+ button — capture button number
- [ ] VOL- button — capture button number
- [ ] TOTAL/CARRY button — capture button number and what it does

## Swing speed
- [ ] Capture the actual speed measurement packet — the 0x73 acks only contain a timestamp, speed must arrive in a separate packet (different cmd?)
- [ ] What is `d[4]=0x01` in SwingSpeedAck — shot counter? Session counter?
- [ ] What are the constant bytes `d[11..17] = FF 01 00 00 60 41 00` — loft angle (14.0 float at d[13..16])?

## Unknown shot fields
- [ ] `ShotMetadata.Unknown1` (p[24..27]) — capture value across multiple shots with different clubs/settings
- [ ] `ShotData.Tail` bytes — any of the seq 2–6 packets longer than the minimum parsed length?

## Handshake
- [ ] Confirm ShotReady is needed after handshake (currently not sent — device may not arm itself)
