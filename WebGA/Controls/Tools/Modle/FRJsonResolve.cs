using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;

namespace WebGA.Controls.Tools
{
    public sealed class FRJsonResolve
    {
        [DataContract]
        public class BaseJR
        {
            [DataMember]
            public int error_conde { get; set; }
            [DataMember]
            public string error_msg { get; set; }
            [DataMember]
            public long log_id { get; set; }
            [DataMember]
            public long timestamp { get; set; }
            [DataMember]
            public long cached { get; set; }
            [DataMember]
            public result result{ get; set; }

            public override string ToString()
            {
                string li = "<li>";
                string eli = "</li>";
                StringBuilder sb = new StringBuilder();
                sb.Append("<ul>");
                sb.Append(li + "识别结果码:" + error_conde.ToString() + eli);
                sb.Append(li + "结果码描述:" + error_msg.ToString() + eli);
                sb.Append(li + "ID:" + log_id.ToString() + eli);

                try
                {
                    if (error_conde == 0 && error_msg.Equals("SUCCESS"))
                    {
                        if (result != null && result.face_list.Count > 0)
                        {
                            sb.Append(li + "识别人数:" + result.face_num.ToString() + eli);
                            for (int i = 0; i < result.face_list.Count; i++)
                            {
                                sb.Append(li + "====================== " + "第" + (i + 1) + "人" + " ======================" + eli);
                                sb.Append(li + "大概年龄:" + result.face_list[i].age.ToString() + eli);
                                sb.Append(li + "颜值分数:" + result.face_list[i].beauty.ToString() + eli);
                                sb.Append(li + "性别:" + result.face_list[i].gender["type"].ToString() + eli);
                                sb.Append(li + "眼镜:" + result.face_list[i].glasses["type"].ToString() + eli);
                                sb.Append(li + "表情:" + result.face_list[i].exprssion["type"].ToString() + eli);
                                sb.Append(li + "脸型:" + result.face_list[i].face_shape["type"].ToString() + eli);
                                sb.Append(li + "人种:" + result.face_list[i].race["type"].ToString() + eli);
                                sb.Append(li + "光照程度:" + result.face_list[i].quality.illumination.ToString() + eli);
                                sb.Append(li + "人脸模糊程度:" + result.face_list[i].quality.blur.ToString() + eli);
                            }
                        }
                    }
                    sb.Append("</ul>");
                }
                catch (System.Exception ex)
                {
                    
                    sb.Append(ex.ToString());
                }
                

                return sb.ToString();
            }
        }
        
        [DataContract]
        public class result
        {
            [DataMember]
            public uint face_num;//人脸总数
            

            public List<FaceList> face_list;//人脸信息列表
        }

        [DataContract]
        public class FaceList
        {
            [DataMember]
            public uint face_probability;//是否人脸的置信度 是否人脸的概率

            public JObject angle;//角度倾斜度

            [DataMember]
            public uint age;//年龄
            [DataMember]
            public double beauty;//分数
            /// <summary>
            /// type : 表情类型（none，smile，laugh）,probability:置信度
            /// </summary>
            public JObject exprssion;
            /// <summary>
            ///  type : 脸型（square: 正方形 triangle:三角形 oval: 椭圆 heart: 心形 round: 圆形），probability 置信度
            /// </summary>
            public JObject face_shape;
            /// <summary>
            /// type:性别 (male:男性 female:女性)，probability 置信度
            /// </summary>
            public JObject gender;
            /// <summary>
            /// type:眼镜(none,common,sun),probability 置信度
            /// </summary>
            public JObject glasses;
            /// <summary>
            /// type :人种（yellow: 黄种人 white: 白种人 black:黑种人 arabs: 阿拉伯人）,probability 置信度
            /// </summary>
            public JObject race;
            /// <summary>
            /// 人脸质量信息
            /// </summary>
            [DataMember]
            public Quality quality;

        }

        [DataContract]
        public class Quality
        {
            [DataMember]
            public JObject occlusion;
            [DataMember]
            public string blur;//人脸模糊程度
            [DataMember]
            public uint illumination; //光照程度[0-255]
            [DataMember]
            public uint completeness; //人脸完整度
        }

        public enum FRError_Code
        {
            每天流量超限额 = 17,
            QPS超限额 = 18,
            请求总量超限额 = 19,
            图片中没有人脸 = 222202,
            无法解析人脸 = 222203,
            未找到匹配的用户 = 222207,
            人脸有被遮挡 = 223113,
            人脸模糊 = 223114,
            人脸光照不好 = 223115,
            人脸不完整 = 223116,

        }
    }
}
