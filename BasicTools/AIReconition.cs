using System;
using System.Collections.Generic;
using Baidu.Aip.Face;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BasicTools
{
    public class AIReconition:Face
    {
       // public String Token = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

        /// <summary>
        /// 活体检测控制 NONE: 不进行控制 LOW:较低的活体要求(高通过率 低攻击拒绝率) NORMAL: 一般的活体要求(平衡的攻击拒绝率, 通过率) HIGH: 较高的活体要求(高攻击拒绝率 低通过率) 默认NONE
        /// </summary>
        public String liveness_control = "LOW";
        /// <summary>
        /// 图片质量控制 NONE: 不进行控制 LOW:较低的质量要求 NORMAL: 一般的质量要求 HIGH: 较高的质量要求 默认 NONE
        /// </summary>
        public String qualty_control = "NORMAL";

        public int timeOut = 60000;

        private static  String API_KEY = Config.EncryptionConfig ? Encryption.Base64DeCode(Config.Api_Key) : Config.Api_Key;

        private static String SECRET_KEY = Config.EncryptionConfig ? Encryption.Base64DeCode(Config.Secret_Key) : Config.Secret_Key;

        private static String APP_ID = Config.EncryptionConfig ? Encryption.Base64DeCode(Config.Api_Key) : Config.Api_Key;

        public AIReconition()
            : base(API_KEY, SECRET_KEY)
        {
            Timeout = timeOut;
            base.Timeout = timeOut;
        }

        //人脸检测
        public JObject Detect(string image,string imageType)
        {
            //参数
            //图片信息(总数据大小应小于10M)，图片上传方式根据image_type来判断

            //图片类型 BASE64:图片的base64值，base64编码后的图片数据，需urlencode，编码后的图片大小不超过2M;
            //URL:图片的 URL地址( 可能由于网络等原因导致下载图片时间过长);
            //FACE_TOKEN: 人脸图片的唯一标识，调用人脸检测接口时，会为每个人脸图片赋予一个唯一的FACE_TOKEN，同一张图片多次检测得到的FACE_TOKEN是同一个

            // 如果有可选参数
            var options = new Dictionary<string, object>
            {
                //年龄,颜值评分,表情,脸型,性别,是否戴眼镜,人种,人脸质量
                {"face_field","age,beauty,expression,faceshape,gender,glasses,race,quality"},
                //包括age,beauty,expression,faceshape,gender,glasses,landmark,race,quality,facetype,parsing信息
                //逗号分隔. 默认只返回face_token、人脸框、概率和旋转角度 
                {"max_face_num",8}, //最多检测人脸数，最大为10
                {"face_type","LIVE"}
                //人脸的类型 LIVE表示生活照：通常为手机、相机拍摄的人像图片、或从网络获取的人像图片等
                //IDCARD表示身份证芯片照：二代身份证内置芯片中的人像照片 WATERMARK表示带水印证件照：一般为带水印的小图，如公安网小图
                //CERT表示证件照片：如拍摄的身份证、工卡、护照、学生证等证件图片 默认LIVE
            };

            // 调用人脸检测，可能会抛出网络等异常，请使用try/catch捕获
            var result = Detect(image, imageType, options);
            return result;
        }

        /// <summary>
        /// 人脸注册
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="imageType">图片格式</param>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">用户所属组ID</param>
        /// <param name="userInfo">用户信息</param>
        public JObject UserAdd(string image, string imageType, string userId, string groupId, string userInfo)
        {
            var options = new Dictionary<string, object>
            {
                {"user_info",userInfo},    //用户资料，长度限制256B
                {"quality_control",qualty_control},
                {"liveness_control",liveness_control} 
            };

            var result = UserAdd(image, imageType, userId, groupId, options);

            return result;
        }

        /// <summary>
        /// 人脸搜索
        /// </summary>
        /// <param name="image">图片（根据图片格式获取）</param>
        /// <param name="imageType">图片格式(URL，BASE64,TOKEN)</param>
        /// <param name="groupIdList">指定用户组ID搜索','逗号隔开</param>
        /// <param name="userId">指定用户进行比较。人脸认证功能</param>
        /// <param name="maxUserNum">查找后返回的用户数量,最多20个</param>
        /// <returns></returns>
        public JObject Search(string image, string imageType, string groupIdList, string userId, int maxUserNum)
        {
            var options = new Dictionary<string, object>
                {
                    {"quality_control",qualty_control},
                    {"liveness_control",liveness_control},
                    {"user_id",userId},
                    {"max_user_num",maxUserNum}
                };

            var result = Search(image, imageType, groupIdList, options);

            return result;
        }

        /// <summary>
        /// 人脸对比（两张图片对比）
        /// </summary>
        /// <param name="imgBase64_A">图片A</param>
        /// <param name="imgBase64_B">图片B</param>
        /// <returns></returns>
        public JObject Math(string imgBase64_A, string imgBase64_B)
        {
            var faces = new JArray
            {
                new JObject {
                    {"image",imgBase64_A},
                    {"image_type","BASE64"},
                    {"face_type","LIVE"},
                    {"quality_control",qualty_control},
                    {"liveness_control",liveness_control},
                },
                new JObject{
                    {"image",imgBase64_B},
                    {"image_type","BASE64"},
                    {"face_type","LIVE"},
                    {"quality_control",qualty_control},
                    {"liveness_control",liveness_control},
                }
            };

            var result = Match(faces);

            return result;
        }

        /// <summary>
        /// 图片转换为BASE64
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        /// <returns></returns>
        public static string ReadImage(string imgPath)
        {
            return Convert.ToBase64String(File.ReadAllBytes(imgPath));
        }
    
    }
}
