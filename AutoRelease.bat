IF NOT EXIST WPrime64\. GOTO END
CLS
rem リリースして qrum します。
PAUSE

CALL ff
cx **

CD %~dp0.

IF NOT EXIST WPrime64\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\Prime64.zip S:\リリース物\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END
