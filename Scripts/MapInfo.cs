using Godot;
using System;
using System.Collections.Generic;
using System.IO;

class MapInfo
{
    private static int chunkAmount;
    private static int chunkHeight;
    private const int chunkWidth = 16;
    private const string HEADER_SUFFIX = "/map.map";
    private const string CHUNK_SUFFIX = "/chunk";
    private const string CHUNK_EXTENSION = ".chn";
    private const string STAR_SUFFIX = "/stars.str";
    private static string audioPath;
    private static string themePath;
    private static List<string> fileContent;
    private static List<List <string>> blocks = new List<List<string>>();
    private static List<int> layers = new List<int>();
    private static List<Vector2> stars = new List<Vector2>();
    private string pathToMapFolder;

    public static int ChunkAmount
    {
        private set
        {
            chunkAmount = value;
        }
        get
        {
            return chunkAmount;
        }
    }
    
	public static int ChunkHeight
    {
        private set
        {
            chunkHeight = value;
        }
        get
        {
            return chunkHeight;
        }
    }
    
    public static int ChunkWidth
    {
        get
        {
            return chunkWidth;
        }
    }

	public static string AudioPath
    {
        private set
        {
            audioPath = value;
        }
        get
        {
            return audioPath;
        }
    }
    
	public static string ThemePath
    {
        private set
        {
            themePath = value;
        }
        get
        {
            return themePath;
        }
    }

	public static List<int> Layers
    {
        get
        {
            return layers;
        }
    }
    
	public static List<List<string>> Blocks
    {
        get
        {
            return blocks;
        }
    }

	public static List<Vector2> Stars
    {
        get
        {
            return stars;
        }
    }

    public MapInfo(){}
    
	public MapInfo(string pathToMapFolder)
    {
        this.pathToMapFolder = pathToMapFolder;
        Load();
    }
    
	private void Load()
    {
        fileContent=loadFileContent(HEADER_SUFFIX);
        loadChunkAmount();
        loadChunkHeight();
        loadAudioPath();
        loadThemePath();
        for (int i = 0; i < chunkAmount; i++)
            loadBlocks(i+1);
        loadStars();
    }
    
	private List<string> loadFileContent(string pathSuffix)
    {
        string pathToMapHeaderFile = pathToMapFolder + pathSuffix;
        var lines = System.IO.File.ReadLines(pathToMapHeaderFile);
        List<string> result = new List<string>(lines);
        return result;
    }
    
	private void loadChunkAmount()
    {
        int headerLine = findHeaderType("chunkCount");
        chunkAmount = Int32.Parse(loadHeaderData(headerLine));
    }
    
	private void loadChunkHeight()
    {
        int headerLine = findHeaderType("chunkHeight");
        chunkHeight = Int32.Parse(loadHeaderData(headerLine));
    }
    
	private void loadAudioPath()
    {
        int headerLine = findHeaderType("audio");
        audioPath = loadHeaderData(headerLine);
    }
    
	private void loadThemePath()
    {
        int headerLine = findHeaderType("theme");
        themePath = loadHeaderData(headerLine);
    }
    
	private int findHeaderType(string type)
    {
        for (int i = 0; i < fileContent.Count; i++)
            for (int j = 0; j < type.Length; j++)
            {
                if (type[j] != fileContent[i][j])
                    break;
                if (j == type.Length-1)
                    return i;
            }
        return -1; //error
    }
    
	private string loadHeaderData(int lineNr)
    {
        if (lineNr >= fileContent.Count || lineNr < 0)
            return "ERROR: 001"; //param out of range
        string data = "";
        bool colonEncountered = false;
        for (int i = 0; i < fileContent[lineNr].Length; i++)
        {
            if (colonEncountered)
                data += fileContent[lineNr][i];
            if (fileContent[lineNr][i] == ':')
                colonEncountered = true;
        }
        return data;
    }
    
	private void loadBlocks(int chunkNr)
    {
        List<string> chunkRaw = loadFileContent(CHUNK_SUFFIX + chunkNr + CHUNK_EXTENSION);
        layers.Add(chunkRaw.Count / chunkHeight);
        List<string> chunkFormatted = loadSingleBlocks(chunkRaw);
        blocks.Add(chunkFormatted);
    }
    
	private List<string> loadSingleBlocks(List<string> source)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < source.Count; i++)
        {
            string dataGetter="";
            for (int j = 0; j < source[i].Length; j++)
            {
                if (source[i][j] != ' ')
                    dataGetter += source[i][j];
                if (j % 4 == 3 || j == source[i].Length - 1)
                {
                    result.Add(dataGetter);
                    dataGetter = "";
                }
            }
        }
        return result;
    }

    private void loadStars()
    {
        List<string> lines = loadFileContent(STAR_SUFFIX);
        for (int i = 0; i < lines.Count; i++)
            stars.Add(loadSingleStar(lines[i]));
    }

    private Vector2 loadSingleStar(string line)
    {
        Vector2 coors = new Vector2();
        bool colonOccured = false;
        string xAxis = "";
        string yAxis = "";
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == ':')
                colonOccured = true;
            else
            {
                if (colonOccured)
                    yAxis += line[i];
                else
                    xAxis += line[i];
            }
        }
        int intXAxis = Int32.Parse(xAxis);
        int intYAxis = Int32.Parse(yAxis);
        coors.x = intXAxis;
        coors.y = intYAxis;
        return coors;
    }
}