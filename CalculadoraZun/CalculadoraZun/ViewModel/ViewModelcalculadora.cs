using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculadoraZun.ViewModel
{
    public class ViewModelcalculadora : ViewModelBase
    {
        int currentState = 1;
        String mathOperator;

        double firstNumber;

        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                if (firstNumber != value)
                {
                    firstNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        double secondNumber;

        public double SecondNumber
        {
            get { return secondNumber; }
            set
            {
                if (secondNumber != value)
                {
                    secondNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        string result;
        public string Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }

        string operation;
        public string Operation
        {
            get { return operation; }
            set
            {
                if (operation != value)
                {
                    operation = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand OnSelectOperator { protected set; get; }
        public ICommand OnClear { protected set; get; }
        public ICommand OnCalculate { protected set; get; }
        public ICommand OnSelectNumber { protected set; get; }

        public ViewModelcalculadora()
        {
            OnSelectNumber = new Command<string>(
                execute: (string parameter) =>
                {
                    string pressed = parameter;

                    if (this.Result == "0" || currentState < 0)
                    {
                        this.Result = "";
                        if (currentState < 0)
                            currentState *= -1;
                    }

                    this.Result += pressed;

                    double number;
                    if (double.TryParse(this.Result, out number))
                    {
                        this.Result = number.ToString("N0");
                        if (currentState == 1)
                        {
                            firstNumber = number;
                        }
                        else
                        {
                            secondNumber = number;
                        }
                    }
                });

            OnClear = new Command(() =>
            {
                firstNumber = 0;
                secondNumber = 0;
                currentState = 1;
                this.Result = "0";
            });

            OnSelectOperator = new Command<string>(
                execute: (string parameter) =>
                {
                    currentState = -2;
                    string pressed = parameter;
                    mathOperator = pressed;
                });

            OnCalculate = new Command(() =>
            {
                if (currentState == 2)
                {
                    var result = calculadorasimple.Calculate(firstNumber, secondNumber, mathOperator);
                    Result = result.ToString();
                    firstNumber = (double)result;
                    currentState = -1;
                }
            });
        }

    }

}
