using System.Text.RegularExpressions;
        public static byte[] GetResetUnstagedLinesAsPatch(GitModule module, string text, int selectionPosition, int selectionLength, Encoding fileContentEncoding)
            const string fileMode = "100000"; // given fake mode to satisfy patch format, git will override this
        public void LoadPatch(string text, Encoding filesContentEncoding)
        public void LoadPatchFile(string path, Encoding filesContentEncoding)
            var text = File.ReadAllText(path, GitModule.LosslessEncoding);
            LoadPatch(text, filesContentEncoding);
    internal sealed class PatchLine
        public string Text { get; private set; }
        public PatchLine(string text, bool selected = false)
        {
            Text = text;
            Selected = selected;
        }

            return new PatchLine(Text, Selected);
    internal sealed class SubChunk
        public List<PatchLine> PreContext { get; } = new List<PatchLine>();
        public List<PatchLine> RemovedLines { get; } = new List<PatchLine>();
        public List<PatchLine> AddedLines { get; } = new List<PatchLine>();
        public List<PatchLine> PostContext { get; } = new List<PatchLine>();
        public string WasNoNewLineAtTheEnd { get; set; }
        public string IsNoNewLineAtTheEnd { get; set; }
    internal sealed class Chunk
        private readonly List<SubChunk> _subChunks = new List<SubChunk>();
        private SubChunk CurrentSubChunk
        private void AddContextLine(PatchLine line, bool preContext)
        private void AddDiffLine(PatchLine line, bool removed)
        /// <summary>
        /// Parses a header line, setting the start index.
        /// </summary>
        /// <remarks>
        /// An example header line is:
        /// <code>
        ///  -116,12 +117,15 @@ private string LoadFile(string fileName, Encoding filesContentEncoding)
        /// </code>
        /// In which case the start line is <c>116</c>.
        /// </remarks>
        private void ParseHeader(string header)
            var match = Regex.Match(header, @".*-(\d+),");
            if (match.Success)
            {
                _startLine = int.Parse(match.Groups[1].Value);
            }
                    var patchLine = new PatchLine(line);
            Chunk result = new Chunk { _startLine = 0 };

            if (gitEol == "crlf")
            else if (gitEol == "native")
                var patchLine = new PatchLine((reset ? "-" : "+") + preamble + line);
                // do not refactor, there are no breakpoints condition in VS Express
                    if (line != string.Empty)
            return new ChunkList
            {
                Chunk.FromNewFile(
                    module,
                    text,
                    selectionPosition,
                    selectionLength,
                    reset,
                    filePreabmle,
                    fileContentEncoding)
            };
        private string ToPatch(SubChunkToPatchFnc subChunkToPatch)