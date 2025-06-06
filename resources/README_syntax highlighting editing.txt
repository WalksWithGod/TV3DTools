To edit the syntax highlighting (perhaps trying the different ones in this directory)

1) Note the following directory contains the .xshd  (xml syntax highlighting definition) files
- \tvtools\libs\ICSharpCode.TextEditor\Project\Resources\
- Add a new .xshd to that folder
- In VS.NET, for the ICSharpCode.TextEditor project, right click on the "Resources" folder and click 
  Add Existing
- Select the .xshd file you wish to add and click OK.
- The resource should now be added to the Solution under the REsources folder.
- Click it, and in the properties grid for that resource, set it to "Embeddable Resource"

2) In the ICSharpeCode.TextEditor project, under the "Resources" folder find a file named
   "SyntaxModes.xml"
- double click that file.
- using the existing Mode's as a guide, modify the existing "HLSL" entry to point to the new file.
3) Recompile.  Done.