# SE_Security_Project
This is our semester project for Software Engineering. We are doing a security based project with OMNIKEY readers and Mifareclassic


Useful Notes:
KeyNumber: See Section: 5.2 Key Locations

**Contactless Card Communication**
To enhance user experience OMNIKEY 5022 supports so called key
caching that reduces the number of authentication calls required to access certain areas of a card that use the same key. Key caching is disabled by default.

Communication with MIFARE Classic, MIFARE Plus, MIFARE Ultralight and iCLASS credentials is
normally done using the PC/SC APDUs


**FOR UI**
Use PC/SC API commands to create an application.



**PC/SC APDU Notes**

Loading Keys:
All keys except MIFARE keys must be loaded during secure
session. MIFARE keys can be loaded when secure session is established or not

It will work with any card type. OR it can be sent using SCardControl()


MiFare Data Sheet
Section 8.7 Accessing the Data blocks. VERY USEFUL
