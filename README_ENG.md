# ML.Net text classification
This is a small test project of a .NET console application that can be used to classify assessments.

Using [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet), a model is created with data and trained when it is started for the first time.

## What is needed?
- [![NuGet Status](https://img.shields.io/nuget/v/Microsoft.ML.svg?style=flat)](https://www.nuget.org/packages/Microsoft.ML/)
- [.NET Core 8](https://www.microsoft.com/net/learn/get-started)

## First start
1. Before the application can be started, you must specify a file path with the data to create/train in the parameters.
2. When it is started for the first time, the model is first created and trained with the data.
3. After creation and training is complete, the model is saved locally in the project directory under ".../Models/StimmungAI.zip".
4. Now you can enter a rating as desired.
5. Afterwards, it is shown each time whether the input is positive or negative, including the score achieved.
## Training data
```
The dataset used for this project comes from "From Group to Individual Labels using Deep Features",
Kotzias et. al. KDD 2015, and is hosted in the UCI Machine Learning Repository - Dua, D. and Karra Taniskidou, E. (2017).
UCI Machine Learning Repository [http://archive.ics.uci.edu/ml ].
Irvine, CA: University of California, School of Information and Computer Science.
```

- The data was translated into German by me using Google Translate.
- Each rating is classified with 1 or 0. (1 = Positive, 0 = Negative)
- The rating and classification are separated by a TAB.

(Feel free to use your own data. This will of course work with any language.)

## Re-creating the model including training
If you rename or delete the model in the directory ".../Models/StimmungAI.zip", the model will be re-created and trained the next time you start the program.
