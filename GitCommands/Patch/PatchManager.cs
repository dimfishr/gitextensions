            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, out var header);
            {
            }
            // git apply has problem with dealing with autocrlf
            // I noticed that patch applies when '\r' chars are removed from patch if autocrlf is set to true
            {
            }
            {
            }
            {
            }
        public static byte[] GetSelectedLinesAsPatch(string text, int selectionPosition, int selectionLength, bool staged, Encoding fileContentEncoding, bool isNewFile)
            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, out var header);
            {
            }
            // if file is new, --- /dev/null has to be replaced by --- a/fileName
            {
            }
            {
            }

            string[] headerLines = header.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            {
                {
                }
            }
                {
                }
                {
                }
        public static byte[] GetSelectedLinesAsNewPatch(GitModule module, string newFileName, string text, int selectionPosition, int selectionLength, Encoding fileContentEncoding, bool reset, byte[] filePreabmle)
            string fileMode = "100000"; // given fake mode to satisfy patch format, git will override this

            {
            }
            {
            }

            ChunkList selectedChunks = ChunkList.FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreabmle, fileContentEncoding);
            {
            }

            // git apply has problem with dealing with autocrlf
            // I noticed that patch applies when '\r' chars are removed from patch if autocrlf is set to true
            {
            }
            {
            }
            {
            }
            var s = new StringBuilder();

            byte[] bs = Encoding.UTF8.GetBytes(input);
        // TODO encoding for each file in patch should be obtained separately from .gitattributes
            {
            }
                {
                }
        public string WasNoNewLineAtTheEnd;
        public string IsNoNewLineAtTheEnd;
            {
            }
                    {
                    }
                    {
                    }

                    {
                    }
                    {
                    }

            {
            }

            {
            }

            // stage no new line at the end only if last +- line is selected
            {
            }

            {
            }
        // patch base is changed file
            {
            }
                    {
                    }
                    {
                    }

            {
            }

            {
            }

            {
            }
            {
            }
        private int _startLine;
        private List<SubChunk> _subChunks = new List<SubChunk>();
        private SubChunk _currentSubChunk;
                if (_currentSubChunk == null)
                    _currentSubChunk = new SubChunk();
                    _subChunks.Add(_currentSubChunk);

                return _currentSubChunk;
            {
            }
            {
            }
            // if postContext is not empty @line comes from next SubChunk
            {
                _currentSubChunk = null; // start new SubChunk
            }
            {
            }
            {
            }
            return int.TryParse(header, out _startLine);
            {
            }

                    // do not refactor, there are no break points condition in VS Experss
                    {
                    }
                    {
                    }
                        {
                        }
                        {
                        }
                    {
                    }
        public static Chunk FromNewFile(GitModule module, string fileText, int selectionPosition, int selectionLength, bool reset, byte[] filePreabmle, Encoding fileContentEncoding)
            result._startLine = 0;
            {
            }
            {
            }
            {
            }
            string[] lines = fileText.Split(new[] { eol }, StringSplitOptions.None);
                string preamble = i == 0 ? new string(fileContentEncoding.GetChars(filePreabmle)) : string.Empty;

                // do not refactor, there are no breakpoints condition in VS Experss
                {
                }
                            // if the last line is selected to be reset and there is no new line at the end of file
                            // then we also have to remove the last not selected line in order to add it right again with the "No newline.." indicator
                            PatchLine lastNotSelectedLine = result.CurrentSubChunk.RemovedLines.LastOrDefault(l => !l.Selected);

                {
                }

            foreach (SubChunk subChunk in _subChunks)
            {
            }
            diff = "@@ -" + _startLine + "," + removedCount + " +" + _startLine + "," + addedCount + " @@".Combine("\n", diff);
        public static ChunkList GetSelectedChunks(string text, int selectionPosition, int selectionLength, out string header)

            // When there is no patch, return nothing
            {
            }
            {
            }
            string[] chunks = diff.Split(new[] { "\n@@" }, StringSplitOptions.RemoveEmptyEntries);

                // if selection intersects with chunsk
                    {
                    }

        public static ChunkList FromNewFile(GitModule module, string text, int selectionPosition, int selectionLength, bool reset, byte[] filePreabmle, Encoding fileContentEncoding)
            Chunk chunk = Chunk.FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreabmle, fileContentEncoding);
            {
            }
            return result;