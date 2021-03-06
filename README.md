# What is this?
If you've found that the localization task is quite boring and frustrating, this is the tool for you.
![](https://github.com/teonsen/ResxMultiLang/wiki/images/img1.png)

It can,
- Read string data from .resx files.
- Append a word with automated multi language translation (Google's Translation-API)
- Edit on spread sheet if you don't like mechanical translation.
- Write them back into .resx files.

# How can I use it?
1. Make these 4 .resx files. Empty resource file will do.
  - Resources.resx (English)(base)
  - Resources.zh-CN.resx (Simplified Chinese)
  - Resources.zh-TW.resx (Traditional Chinese)
  - Resources.ja-JP.resx (Japanese)

2. Select the base .resx file from File menu.

3. Type a word to localize into the text box. Or edit on the spreadsheet.

4. Save

That's it!!

# Credits
This tool relies on [ReoGrid](https://github.com/unvell/ReoGrid) and [Google Cloud Translation API](https://developers.google.com/api-client-library/dotnet/apis/translate/v2)
