IF NOT EXIST WPrime64\. GOTO END
CLS
rem �����[�X���� qrum ���܂��B
PAUSE

CALL ff
cx **

CD %~dp0.

IF NOT EXIST WPrime64\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\Prime64.zip S:\�����[�X��\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END
