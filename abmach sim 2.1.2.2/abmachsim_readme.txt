2/08/2008 version 2.1.2.1 single precision
changed new feedrate run type to replace feedrates with default feedrate before run
changed iteration number to change depeding on run type
added default feedrate input to preferences form

2/07/2008 version 2.1.1.3 single precision
fixed bug: fixed problem with whitespace added before N in END.

11/12/2007 version 2.1.1.2 single precision 
fixed bug: set depth location now works even if cross hair is not active

9/10/2007 version 2.0.1.4 and version 2.1.1.1
Fixed bug: added absolute value function to mrr adjust function so it works if target depth is positive or negative.

9/10/2007 Version 2.1.1.0
Created Single precision versions- 32 bit precision for surface arrays
ABMACHSimSingle.exe

9/10/2007 version 2.0.1.3 and version 2.1.1.0
renamed ABMACHSim2.exe to ABMACHSimDouble.exe
Fixed bug: when ccomp was changed mask surface and mi surface did not get invalidated
Added messages to exception handling in modelrun subroutine.

9/6/2007 version 2.0.1.2
added mask input separate from mi input
mask input is for masking off areas you don't want new feedrates 
mi input is for changing the mi of a surface.

mrr=(mrr from parameter file) *mi

mi>1 is softer( ie more machinable)
mi<1 is harder
mi=0 may cause exception if no material is removed at a point where new feedrates are to be calculated.  

for mi input using dxf file, z value of point is converted to mi value

6/13/2007 version 1.5.1.3
changed logic in subtract surface- removed mi<>0 from check in main subtract surface loop

5/31/2007 version 1.5.1.2
fixed conflict in newfeedout subroutine between maxdepth calc preference and multidirection groove
Now, if groove is multidirection, footprint calculation is used even if maxdepth preference is checked

5/23/2007
removed z=0 error check from target file subroutine

5/7/2007 version 1.5.1.1
added renumber file function to tools menu
rewrote onthefly jeton function to mimich pete's SiCarbide grooving routine

5/3/2006
moved MRR function defaults and theta crit defaults to preferences menu
changed default for S and R channels 

4/14/2006
fixed error in 5th axis moves to correct for relative change in feedrate due to jet changing angle and position 

3/27/2006
fixed mrr coefficient noramlization factors to make mrr value more realistic
fixed depth adjust sub so it exits model run if nominal depth is reached before end.

3/24/2006
changed slopefactor by taking square root of cosine.  this broadens the angleresponse of the slopefactor equation.  this was to help with feed rate calc for divering converginn rocket channels.  

3/20/2006
fixed bug in main when file open dialog cancel button clicked then model run button was disabled
changed to model run button disable only when file opendialog OK button clicked

3/17/2006
fixed bug in newfeedout when ccomp was changed arrays were not resized
fixed bug in parminput when other type of mrr was saved type 13 was still reloaded  as default

3/13/2006
fixed bug in parse subroutine when running par code. code counted all lines as comments if repeat strings were not defined
added gaussian polynominal approximation to mrr coefficients=type 4

3/9/2006
fixed bug in CSV file output routine. model did not calc arraysize correctly for csv output

3/7/2006
fixed program exit routine when control box is clicked

3/6/2006 
fixed mrr update problem with parameter input form changed byVal to byRef
fixed program exit routine with unsaved file question

2/10/2006 
removed deltabfactor call from subtract surface

2/1/2006 
updated machintags.xml to include new machine syntax
changed scram syntax to match quintax for ccomp readin
 