using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BasicTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;


namespace WebGA.Controls.Tools
{
    public class FaceReconitionJsonResolve
    {
        static AIReconition faceReconition = new AIReconition();

        public static FRJsonResolve.BaseJR FR_DetectResult(string img,string imgType)
        {
            JObject FRResult = faceReconition.Detect(img,imgType);

            FRJsonResolve.BaseJR jr = JsonConvert.DeserializeObject<FRJsonResolve.BaseJR>(FRResult.ToString());

            if (jr.error_conde == 0 && jr.error_msg.Equals("SUCCESS"))
            {
                jr.result.face_list = GetFaceList((JArray)FRResult["result"]["face_list"]);
            }

            return jr;
        }

        private static List<FRJsonResolve.FaceList> GetFaceList(JArray source)
        {
            List<FRJsonResolve.FaceList> list = new List<FRJsonResolve.FaceList>();

            if (source != null && source.Count > 0)
            {
                foreach (var item in source)
                {
                    JObject jItem = JObject.Parse(item.ToString());

                    FRJsonResolve.FaceList result = JsonConvert.DeserializeObject<FRJsonResolve.FaceList>(jItem.ToString());

                    result.angle = jItem["angle"] as JObject;
                    result.exprssion = jItem["expression"] as JObject;
                    result.face_shape = jItem["face_shape"] as JObject;
                    result.gender = jItem["gender"] as JObject;
                    result.glasses = jItem["glasses"] as JObject;
                    result.race = jItem["race"] as JObject;

                    list.Add(result);
                }   
            }
            return list;
        }

        /*
        public static string FRToString(FRJsonResolve.BaseJR jr )
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("识别结果码:" + error_conde.ToString());
            sb.Append("结果码描述:" + error_msg.ToString());
            sb.Append("ID:" + log_id.ToString());
            sb.Append("识别人数:" + result.face_num.ToString());

            for (int i = 0; i < result.face_list.Count; i++)
            {
                sb.Append("====================== " + "第" + (i + 1) + "人" + " ======================");
                sb.Append("大概年龄:" + result.face_list[i].age.ToString());
                sb.Append("颜值分数:" + result.face_list[i].beauty.ToString());
                sb.Append("性别:" + result.face_list[i].gender[0] .ToString());
                sb.Append("眼镜:" + result.face_list[i].glasses[0] .ToString());
                sb.Append("人种:" + result.face_list[i].race[0] .ToString());
                sb.Append("光照程度:" + result.face_list[i].illumination.ToString());
                sb.Append("人脸模糊程度:" + result.face_list[i].blur .ToString());
            }

        }*/

    }
}
