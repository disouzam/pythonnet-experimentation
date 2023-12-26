ECHO ON
@REM Example of bash script to install packages like Numpy, pandas and Scikit-learn

ECHO %1

cd %1

dir

ECHO "Installing Numpy"
call python.exe -m pip install Numpy

ECHO "Installing pandas"
call python.exe -m pip install pandas

ECHO "Installing Scikit-learn"
call python.exe -m pip install scikit-learn