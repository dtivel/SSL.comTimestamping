# SSL.com Timestamp Service Certificate Chain Building Repro

## Repro (Windows only)
1. Clone this repository.

   ```
   git clone https://github.com/dtivel/SSL.comTimestamping.git
   ```

2. Open a PowerShell prompt, path into the repository root directory and execute:

   ```PowerShell
   .\run.ps1
   ```

The output will be:

```text
The current certificate chain is (leaf -> root):

  0: Subject:    CN=SSL.com Timestamping Unit 2023 R1, O=SSL Corp, L=Houston, S=Texas, C=US
     Issuer:     CN=SSL.com Timestamping Issuing RSA CA R1, O=SSL Corp, L=Houston, S=Texas, C=US
     NotBefore:  2023-02-23 16:43:27.000Z
     NotAfter:   2033-02-20 16:43:26.000Z
     SHA-1:      A706EB69A989C743D4D4AFABF7872FFB95B58104
     SHA-256:    3422387477ABEC7DE72B6241624735D278B9B44B92C33A14B2797C2A28C5814C

  1: Subject:    CN=SSL.com Timestamping Issuing RSA CA R1, O=SSL Corp, L=Houston, S=Texas, C=US
     Issuer:     CN=SSL.com Root Certification Authority RSA, O=SSL Corporation, L=Houston, S=Texas, C=US
     NotBefore:  2019-11-13 18:50:05.000Z
     NotAfter:   2034-11-12 18:50:05.000Z
     SHA-1:      84DC2F563A1AAA690C468F3B56EF2D63AEC7CA39
     SHA-256:    5F4D2C0E0CBA7D1FB600EDD3506D4331C866A11F20D137054EE39CF514576679

  2: Subject:    CN=SSL.com Root Certification Authority RSA, O=SSL Corporation, L=Houston, S=Texas, C=US
     Issuer:     CN=Certum Trusted Network CA, OU=Certum Certification Authority, O=Unizeto Technologies S.A., C=PL
     NotBefore:  2018-09-11 09:26:47.000Z
     NotAfter:   2023-09-11 09:26:47.000Z
     SHA-1:      FF95E7706B770B38AD8D8EABE014061F69A86800
     SHA-256:    ACF718DF838E640051777D1947F51620E8D804BA186553AE52FC9811B5D34B8B

  3: Subject:    CN=Certum Trusted Network CA, OU=Certum Certification Authority, O=Unizeto Technologies S.A., C=PL
     Issuer:     CN=Certum Trusted Network CA, OU=Certum Certification Authority, O=Unizeto Technologies S.A., C=PL
     NotBefore:  2008-10-22 12:07:37.000Z
     NotAfter:   2029-12-31 12:07:37.000Z
     SHA-1:      07E032E020B72C3F192F0628A2593A19A70F069E
     SHA-256:    5C58468D55F58E497E743982D2B50010B6D165374ACF83A7D4A32DB768C4408E

Overall chain status:  OK


The new certificate chain is (leaf -> root):

  0: Subject:    CN=SSL.com Timestamping Unit 2023 R1, O=SSL Corp, L=Houston, S=Texas, C=US
     Issuer:     CN=SSL.com Timestamping Issuing RSA CA R1, O=SSL Corp, L=Houston, S=Texas, C=US
     NotBefore:  2023-02-23 16:43:27.000Z
     NotAfter:   2033-02-20 16:43:26.000Z
     SHA-1:      A706EB69A989C743D4D4AFABF7872FFB95B58104
     SHA-256:    3422387477ABEC7DE72B6241624735D278B9B44B92C33A14B2797C2A28C5814C

  1: Subject:    CN=SSL.com Timestamping Issuing RSA CA R1, O=SSL Corp, L=Houston, S=Texas, C=US
     Issuer:     CN=SSL.com Root Certification Authority RSA, O=SSL Corporation, L=Houston, S=Texas, C=US
     NotBefore:  2019-11-13 18:50:05.000Z
     NotAfter:   2034-11-12 18:50:05.000Z
     SHA-1:      84DC2F563A1AAA690C468F3B56EF2D63AEC7CA39
     SHA-256:    5F4D2C0E0CBA7D1FB600EDD3506D4331C866A11F20D137054EE39CF514576679

  2: Subject:    CN=SSL.com Root Certification Authority RSA, O=SSL Corporation, L=Houston, S=Texas, C=US
     Issuer:     CN=SSL.com Root Certification Authority RSA, O=SSL Corporation, L=Houston, S=Texas, C=US
     NotBefore:  2016-02-12 17:39:39.000Z
     NotAfter:   2041-02-12 17:39:39.000Z
     SHA-1:      B7AB3308D1EA4477BA1480125A6FBDA936490CBB
     SHA-256:    85666A562EE0BE5CE925C1D8890A6F76A87EC16D4D7D5F29EA7419CF20123B69

Overall chain status:  OK

```