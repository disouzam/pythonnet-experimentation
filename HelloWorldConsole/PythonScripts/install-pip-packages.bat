ECHO ON
@REM Example of bash script to install packages like Numpy, pandas and Scikit-learn

ECHO %1

cd %1

dir

ECHO "Updating pip version"
call python.exe -m pip install --upgrade pip

ECHO "Installing all required packages"
call python.exe -m pip install -r requirements.txt