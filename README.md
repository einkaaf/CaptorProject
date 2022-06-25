# Kaptcha
Open Source lib For Creating Persian Captcha

For Using This Lib in Unix Base Make Sure `libgdiplus` Is Installed :
```
sudo apt-get install libgdiplus
```

### Installing:
.Net Standard 2+ (.Net Core)
```C#
Install-Package Kaptcha
```
### Usage:
You should use **KaptchaBuilder** to Generate Captcha :
## Defaults:
```C#
var kaptcha = KaptchaBuilder.Init().Build();
```
## Make Noisy Captcha:
```C#
var kaptcha = KaptchaBuilder.Init().UseNoisy().Build();
```       
##  Difficulty Degree Of Captcha:
You can choose between one of these items :
1. Easy
2. Medium
3. Hard
4. UnFair


```C#
var kaptcha = KaptchaBuilder.Init().UseNoisy().Mode(Kaptcha.Model.Enums.Mode.Medium).Build();
```       

## Use Custom Numbers:
In This Case you should Define 4 numbers :  `firstNumberStartRange` , `firstNumberEndRange` , `secondNumberStartRange` , `secondNumberEndRange` :
```C#
var kaptcha = KaptchaBuilder.Init().UseCustomNumbers(9,100,50,90).Build();
``` 

## Use Custom Size :
In This Case you should Define `height` , `width` Of Captcha Image :
```C#
var kaptcha = KaptchaBuilder.Init().UseCustomizeSize(50,100).Build();
```  


## Use Persian Number :
```C#
var kaptcha = KaptchaBuilder.Init().UsePersianNumbers().Build();
```  


## Use Custom Font:
```C#
var kaptcha = KaptchaBuilder.Init().UseFonthPath("c:\\font.ttf").Build();
```  



## Use Random Fonts in Folder:
```C#
var kaptcha = KaptchaBuilder.Init().UseFontFolderPath("c:\\fonts").Build();
```  



## Use Custom Font Size :
```C#
var kaptcha = KaptchaBuilder.Init().UseCustomizeFontSize(45).Build();
```  


## License

[The source code for the site is licensed under the MIT license](https://github.com/erfankm7/Kaptcha/blob/master/LICENSE).
