using System.Collections.Generic;

namespace AOC2019.Modules.Intcode.Instructions
{
    public class OpInstructionCommand
    {
        public ParameterMode ParameterMode1 { get; set; }
        public ParameterMode ParameterMode2 { get; set; }
        public ParameterMode ParameterMode3 { get; set; }

        public OpCodes OpCode { get; set; }

        public int Index { get; set; }
        public List<MemoryCell> Memory { get; set; }
    }
}
