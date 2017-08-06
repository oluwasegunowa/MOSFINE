using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface ITextToSpeech
    {
        void Speak(String text);
    }
}
