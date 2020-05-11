# SE_Security_Project
This is our semester project for Software Engineering. We are doing a security based project with OMNIKEY readers and Mifareclassic

##Client:
Rick Fox rwfox@coloradomesa.edu

##Group Members:

Ethan Ruiz elruiz@mavs.coloradomesa.edu

Mike Tacker matacker@mavs.coloradomesa.edu

Jonah Simon Jpsimon@mavs.coloradomesa.edu

Jake Lambdin 

Addendum Recording:
https://coloradomesa.zoom.us/rec/share/3tVLBL766WVIZKfCymfdd-krAb33eaa80yUdqaAFzxnMZAY6OofwnMA1l6PL7PFL?startTime=1589158102000

Addendum Presentation:
https://docs.google.com/presentation/d/1EWSMXHq0xvuccW0XkCCht1GNloYpO9Ln8-JSDRkyQco/edit?usp=sharing

Showcase Recording:
https://coloradomesa.zoom.us/rec/share/wspnKfbqyE9LQZXStlPiBvcnH93vT6a8hCEY-PAEn0lSDyoaIk5hEcXUPLF-kveC
Showcase Presentation:
https://docs.google.com/presentation/d/1wfbqdbzwLVa5c5Xyq1elfb-HsY8grDsoizuy_aRau_k/edit?usp=sharing

Mifare 1k classic blocks go from 0-63.
in order to read a block you must authenticate.
Use Key A or Key B to Authenticate.
every 4 blocks is a reserved block that gives authentication details for the sector.
4 blocks per sector
16 sectors

Useful Notes:
KeyNumber: See Section: 5.2 Key Locations

**Contactless Card Communication**
To enhance user experience OMNIKEY 5022 supports so called key
caching that reduces the number of authentication calls required to access certain areas of a card that use the same key. Key caching is disabled by default.

Communication with MIFARE Classic, MIFARE Plus, MIFARE Ultralight and iCLASS credentials is
normally done using the PC/SC APDUs


**PC/SC APDU Notes**

Loading Keys:
All keys except MIFARE keys must be loaded during secure
session. Such as iCalss. MIFARE keys can be loaded when secure session is established or not.

It will work with any card type. OR it can be sent using SCardControl()


**MiFare Data Sheet**
Section 8.7 Accessing the Data blocks. VERY USEFUL


Link to the USB sample codes
https://github.com/hidglobal/HID-OMNIKEY-Sample-Codes

Link for example c code
https://github.com/max2344/pcsc-lite/blob/master/doc/example/pcsc_demo.c
