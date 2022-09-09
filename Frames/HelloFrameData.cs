using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class HelloFrameData : FrameData
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Hello;

        public class AuthCrypt
        {
            public string Challenge { get; set; }
            public string Salt { get; set; }
        }

        public string ObsWebSocketVersion { get; set; }

        public int RpcVersion { get; set; }

        public AuthCrypt Authentication { get; set; }

    }
}
