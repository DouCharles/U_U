using UnityEngine;

public static class UserInfo
{
    // 登入時取得username，即可在其他檔案中取得UserInfo.Username
    public static string Username;
    public static string RealName;
    public static string school;
    public static string department;
    public static string room_name;
    public static int room_type;
    public static int level;
    public static int tips;
    public static int error_times;
    public static bool can_moving = true;
    // bar score
    static public float[] score_0 = new float[5] { 25, 30, 43, 34, 15 };
    static public float[] score_1 = new float[6] { 58, 68, 69, 67, 43,  60};
    static public float[] score_2 = new float[2] { 70, 85 };//電機資工
    static public float[] score_3 = new float[7] { 34, 23, 57, 55, 67, 72, 85 };
    static public float[] score_4 = new float[6] { 23, 42, 31, 52, 12, 17 };
    static public float[] score_5 = new float[5] { 47, 29, 34, 9, 8 };
    static public float[] score_6 = new float[14] { 65, 73, 54, 59, 68, 63, 55, 49, 58, 63, 62, 51, 58, 70 };

    static public float[,] pr_0 = new float[5, 4];
    static public float[,] pr_1 = new float[6, 4];
    static public float[,] pr_2 = new float[2, 4];
    static public float[,] pr_3 = new float[7, 4];
    static public float[,] pr_4 = new float[6, 4];
    static public float[,] pr_5 = new float[5, 4];
    static public float[,] pr_6 = new float[14, 4];
}
