# Termii.Core

![Termii.Core](https://raw.githubusercontent.com/SlimAhmad/Termii.Core/main/Termii.Core/termii.png)


[![.NET](https://github.com/SlimAhmad/Termii.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/SlimAhmad/Termii.Core/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Termii.Core?logo=nuget)](https://www.nuget.org/packages/Termii.Core)
![Nuget](https://img.shields.io/nuget/dt/Termii.Core?color=blue&label=Downloads)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)


## Introduction
Termii.Core is a Standard-Compliant .NET library built on top of Termii's API RESTful endpoints to enable software engineers to develop SMS, Email OTP verification solutions in .NET.

## This library implements the following section
Please review the following documents:
- [Switch](https://developer.termii.com/switch)
- [Tokens](https://developer.termii.com/token)
- [Insights](https://developer.termii.com/insights)


## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## How to use this library?
In order to use this library there are prerequisites that you must complete before you can write your first C#.NET program. These steps are as follows:

### Termii Account
You must create an Termii account with the following link:
[Click here](https://accounts.termii.com/#/register)

### Nuget Package 
Install the Termii.Core library in your project.
Use the method best suited for your development preference listed at the Nuget Link above or below.

[![Nuget](https://img.shields.io/nuget/v/Termii.Core?logo=nuget)](https://www.nuget.org/packages/Termii.Core)

### API Keys
Once you've created a Termii account. Now, go ahead and get an API key from the following link:
[Click here](https://accounts.termii.com/#/account/api)

### Hello, World!
Once you've completed the aforementioned steps, let's write our very first program with Standard.AI.OpenAI as follows:

### Switch (Messaging)

### Number Message
This API allows businesses send messages to customers using Termii's auto-generated messaging numbers that adapt to customers location.


#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

            // given
            var request = new NumberMessage
            {
                Request = new NumberMessageRequest
                {
                    ApiKey = "<Your API KEY>",
                    Sms = "Text of a message that would be sent to the destination phone number",
                    To = "<Your Phone Number>"
                }
            };

            // when
            NumberMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendNumberMessageAsync(request);

          

          
        }
    }
}
```

### Send Message
This API allows businesses send text messages to their customers across different messaging channels. 

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

           
            // given
            var request = new SendMessage
            {
                Request = new SendMessageRequest
                {
                    ApiKey = "<Your API Key>",
                    Channel = "generic",
                    From = "E-Wallet",
                    Sms = "generic",
                    To = "<Phone number>",
                    Type = "plain",
                    Media = new SendMessageRequest.MessageMedia
                    {
                       Caption = null,
                       Url = null
                    }
                    
                }
            };

            // when
            SendMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendMessageAsync(request);

          
        }
    }
}
```

### Insights

### Balance
The Balance API returns your total balance and balance information from your wallet, such as currency.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

           
            // given
            string? apiKey = Environment.GetEnvironmentVariable("ApiKey");

            // when
            Balance retrievedTermiiModel =
              await this.termiiClient.Insights.RetrieveBalanceAsync(apiKey);

     

        }
    }
}
```

### History
This Inbox API returns reports for messages sent across the sms, voice & whatsapp channels. Reports can either display all messages on termii or a single message.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

           
             when
            History retrievedTermiiModel =
              await this.termiiClient.Insights.RetrieveHistoryAsync(apiKey);

         

     

        }
    }
}
```

### Tokens

### Send Tokens
The send token API allows businesses trigger one-time-passwords (OTP) across any available messaging channel on Termii. One-time-passwords created are generated randomly and there's an option to set an expiry time.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

           
            // given
            var request = new SendToken
            {
                Request = new SendTokenRequest
                {
                    ApiKey = "<Your API Key>",
                    PinType = "NUMERIC",
                    PinTimeToLive = 5,
                    PinLength = 6,
                    PinAttempts = 10,
                    Channel = "generic",
                    From = "E-Wallet",
                    MessageText = "Your pin is < 1234 >",
                    MessageType = "NUMERIC",
                    PinPlaceholder = "< 1234 >",
                    To = "<Phone number>"
                }
            };

            // when
            SendToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendTokenAsync(request);

     

        }
    }
}
```

### Verify Token
Verify token API, checks tokens sent to customers and returns a response confirming the status of the token. A token can either be confirmed as verified or expired based on the timer set for the token.
#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Termii.Core;
using Termii.Core.Models.Services.Foundations.Termii.Charge;

namespace ExampleTermiiNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);

           // given
            var request = new VerifyToken
            {
                Request = new VerifyTokenRequest
                {
                    ApiKey = "<Your API Key>,
                    Pin = "248140",
                    PinId = "<Pin ID>",
                  
                }
            };

            // when
            VerifyToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendVerifyTokenAsync(request);

         

     

        }
    }
}
```


#### Exceptions

Termii.Core may throw following exceptions:

| Exception Name | When it will be thrown |
| --- | --- |
| `SwitchClientValidationException` | This exception is thrown when a validation error occurs while using the Switch client. For example, if required data is missing or invalid. |
| `SwitchClientDependencyException` | This exception is thrown when a dependency error occurs while using the Switch client. For example, if a required dependency is unavailable or incompatible. |
| `SwitchClientServiceException` | This exception is thrown when a service error occurs while using the Switch client. For example, if there is a problem with the server or any other service failure. |
| `InsightsClientValidationException` | This exception is thrown when a validation error occurs while using the Insights client. For example, if required data is missing or invalid. |
| `InsightsClientDependencyException` | This exception is thrown when a dependency error occurs while using the Insights client. For example, if a required dependency is unavailable or incompatible. |
| `InsightsClientDependencyException` | This exception is thrown when a service error occurs while using the Insights client. For example, if there is a problem with the server or any other service failure. |


## How to Contribute
If you want to contribute to this project please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

If you have a question make sure you either open an issue or send a message [Ahmad Salim](slimahmad6@gmail.com) via mail .

