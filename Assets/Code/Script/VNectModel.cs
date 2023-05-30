using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
///  Position index of joint point
/// </summary>
public enum PositionIndex: int
{
    /// Position index of Joint Landmarks:

    Nose = 0, 
    lEyeInner,
    lEye, 
    lEyeOuter,
    rEyeInner,
    rEye,
    rEyeOuter,
    lEar,
    rEar,
    lMouth,
    rMouth,
    lShoulder,
    rShoulder,
    lElbow,
    rElbow,
    lWrist,
    rWrist,
    lPinky,
    rPinky,
    lIndex,
    rIndex,
    lThumb,
    rThumb,
    lHip,
    rHip,
    lKnee,
    rKnee,
    lAnkle,
    rAnkle,
    lHeel,
    rHeel,
    lFootIndex,
    rFootIndex,
    humanVisible,

    // Calculated coordinates
    head,
    neck,
    chest,
    spine,
    hips,
    centerHead,
    Count,
    None,
}



public static partial class EnumExtend
{
    public static int Int(this PositionIndex i)
    {
        return (int)i;
    }
}


public class VNectModel : MonoBehaviour
{
    public class JointPoint
    {
        ///<summary> 
        /// Class for JointPoint positions
        /// </summary>
        public Vector3 Pos3D = new Vector3();
        public float score3D;

        // Bones
        public Transform Transform = null;
        public Quaternion InitRotation;
        public Quaternion Inverse;
        public Quaternion InverseRotation;

        public JointPoint Child = null;
        public JointPoint Parent = null;

    }

    public class Skeleton
    {
        public GameObject LineObject;
        public LineRenderer Line;
        public JointPoint start = null;
        public JointPoint end = null;

    }

    private List<Skeleton> Skeletons = new List<Skeleton>();
    public Material SkeletonMaterial;
    public bool ShowSkeleton = true;
    private bool useSkeleton;
    public float SkeletonX;
    public float SkeletonY;
    public float SkeletonZ;
    public float SkeletonScale;

    // Joint position and bone position
    private JointPoint[] jointPoints;
    public JointPoint[] JointPoints {get {return jointPoints;}}

    private Vector3 initPosition;   // Initial center position
    private Vector3 jointPositionOffset = Vector3.zero;

    // Avatar 
    public GameObject ModelObject;
    public GameObject Nose;
    private Animator anim;
    private Vector3 avatarDimensions;
    private Vector3 avatarCenter;


    // HMD 
    private InputDevice hmdDevice;
    private Vector3 hmdPosition;
    private Quaternion hmdRotation;
    public PoseVisuallizer3D PoseVisuallizer3D;
    public GameObject Instruction;
    private bool displayText = false;    // ENABLE FOR CALIIBRATION INTERFACE


    
    
    // ENABLE for Calibration interface and scene choice
    void Awake()
    {
        Instruction.SetActive(displayText);
    }
    


    private void Update()
    {
        // HMD position + rotation
        if (hmdDevice.isValid)
        {
            hmdDevice.TryGetFeatureValue(CommonUsages.devicePosition, out hmdPosition);
            hmdDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out hmdRotation);
        }

        // Head rotation
        jointPoints[PositionIndex.head.Int()].Transform.rotation = hmdRotation;

        if (jointPoints != null)
        {
            PoseUpdate();
        }
        
    }


    ///<summary>
    /// Initialize joint points
    ///</summary>
    /// <returns></returns>
    public JointPoint[] Initialize()
    {
        hmdDevice = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);

        jointPoints = new JointPoint[PositionIndex.Count.Int()];
        for (var i = 0; i < PositionIndex.Count.Int(); i++)
        {   
            jointPoints[i] = new JointPoint();
        }

        anim = ModelObject.GetComponent<Animator>();

        avatarDimensions.x = Vector3.Distance(anim.GetBoneTransform(HumanBodyBones.RightHand).position, anim.GetBoneTransform(HumanBodyBones.LeftHand).position);
        avatarDimensions.y = Nose.transform.position.y;
        avatarCenter = GetCenter(gameObject);

        // Right Arm 
        // Removed if-else for Vr that utilized controllers
        jointPoints[PositionIndex.rShoulder.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
        jointPoints[PositionIndex.rElbow.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
        jointPoints[PositionIndex.rWrist.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightHand);
        jointPoints[PositionIndex.rThumb.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
        jointPoints[PositionIndex.rPinky.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);

        // Left Arm
        // Removed if-else for Vr that utilized controllers
        jointPoints[PositionIndex.lShoulder.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        jointPoints[PositionIndex.lElbow.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        jointPoints[PositionIndex.lWrist.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftHand);
        jointPoints[PositionIndex.lThumb.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
        jointPoints[PositionIndex.lPinky.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate); 

        // Head
        // Removed if-else for Vr && Kinectscene
        jointPoints[PositionIndex.lEar.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Head);
        jointPoints[PositionIndex.lEye.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftEye);
        jointPoints[PositionIndex.rEar.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Head);
        jointPoints[PositionIndex.rEye.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightEye);
        jointPoints[PositionIndex.Nose.Int()].Transform = Nose.transform;

        // Right Leg
        jointPoints[PositionIndex.rHip.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        jointPoints[PositionIndex.rKnee.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        jointPoints[PositionIndex.rAnkle.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        jointPoints[PositionIndex.rFootIndex.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.RightToes);

        // Left Leg
        jointPoints[PositionIndex.lHip.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        jointPoints[PositionIndex.lKnee.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        jointPoints[PositionIndex.lAnkle.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        jointPoints[PositionIndex.lFootIndex.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.LeftToes);

        // Spine
        jointPoints[PositionIndex.head.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Head);
        jointPoints[PositionIndex.neck.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Neck);
        jointPoints[PositionIndex.chest.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Chest);
        jointPoints[PositionIndex.spine.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Spine);
        jointPoints[PositionIndex.hips.Int()].Transform = anim.GetBoneTransform(HumanBodyBones.Hips);

        
        // PARENT-CHILD SETUP
        // Right Arm
        jointPoints[PositionIndex.rShoulder.Int()].Child = jointPoints[PositionIndex.rElbow.Int()];
        jointPoints[PositionIndex.rElbow.Int()].Child = jointPoints[PositionIndex.rWrist.Int()];
        jointPoints[PositionIndex.rElbow.Int()].Parent = jointPoints[PositionIndex.rShoulder.Int()];

        // Left Arm
        jointPoints[PositionIndex.lShoulder.Int()].Child = jointPoints[PositionIndex.lElbow.Int()];
        jointPoints[PositionIndex.lElbow.Int()].Child = jointPoints[PositionIndex.lWrist.Int()];
        jointPoints[PositionIndex.lElbow.Int()].Parent = jointPoints[PositionIndex.lShoulder.Int()];

        // Right Leg
        jointPoints[PositionIndex.rHip.Int()].Child = jointPoints[PositionIndex.rKnee.Int()];
        jointPoints[PositionIndex.rKnee.Int()].Child = jointPoints[PositionIndex.rAnkle.Int()];
        jointPoints[PositionIndex.rAnkle.Int()].Child = jointPoints[PositionIndex.rFootIndex.Int()];
        jointPoints[PositionIndex.rAnkle.Int()].Parent = jointPoints[PositionIndex.rKnee.Int()];

        // Left Leg
        jointPoints[PositionIndex.lHip.Int()].Child = jointPoints[PositionIndex.lKnee.Int()];
        jointPoints[PositionIndex.lKnee.Int()].Child = jointPoints[PositionIndex.lAnkle.Int()];
        jointPoints[PositionIndex.lAnkle.Int()].Child = jointPoints[PositionIndex.lFootIndex.Int()];
        jointPoints[PositionIndex.lAnkle.Int()].Parent = jointPoints[PositionIndex.lKnee.Int()];
        
        // Spine
        jointPoints[PositionIndex.lHip.Int()].Child = jointPoints[PositionIndex.lKnee.Int()];
        jointPoints[PositionIndex.lKnee.Int()].Child = jointPoints[PositionIndex.lAnkle.Int()];
        jointPoints[PositionIndex.lAnkle.Int()].Child = jointPoints[PositionIndex.lFootIndex.Int()];
        jointPoints[PositionIndex.lAnkle.Int()].Parent = jointPoints[PositionIndex.lKnee.Int()];
    
        useSkeleton = ShowSkeleton;
        if(useSkeleton)
        {
            // Skeleton lines
            // Right Arm
            AddSkeleton(PositionIndex.rShoulder, PositionIndex.rElbow);
            AddSkeleton(PositionIndex.rElbow, PositionIndex.rWrist);
            AddSkeleton(PositionIndex.rWrist, PositionIndex.rThumb);
            AddSkeleton(PositionIndex.rWrist, PositionIndex.rPinky);

            // Left Arm
            AddSkeleton(PositionIndex.lShoulder, PositionIndex.lElbow);
            AddSkeleton(PositionIndex.lElbow, PositionIndex.lWrist);
            AddSkeleton(PositionIndex.lWrist, PositionIndex.lThumb);
            AddSkeleton(PositionIndex.lWrist, PositionIndex.lPinky);

            // Head
            AddSkeleton(PositionIndex.lEar, PositionIndex.lEye);
            AddSkeleton(PositionIndex.lEye, PositionIndex.Nose);
            AddSkeleton(PositionIndex.rEar, PositionIndex.rEye);
            AddSkeleton(PositionIndex.rEye, PositionIndex.Nose);
            
            // Right Leg
            AddSkeleton(PositionIndex.rHip, PositionIndex.rKnee);
            AddSkeleton(PositionIndex.rKnee, PositionIndex.rAnkle);
            AddSkeleton(PositionIndex.rAnkle, PositionIndex.rFootIndex);

            // Left Leg
            AddSkeleton(PositionIndex.lHip, PositionIndex.lKnee);
            AddSkeleton(PositionIndex.lKnee, PositionIndex.lAnkle);
            AddSkeleton(PositionIndex.lAnkle, PositionIndex.lFootIndex);

            // Torso
            AddSkeleton(PositionIndex.hips, PositionIndex.spine);
            AddSkeleton(PositionIndex.spine, PositionIndex.chest);
            AddSkeleton(PositionIndex.chest, PositionIndex.neck);
            AddSkeleton(PositionIndex.neck, PositionIndex.head);
            AddSkeleton(PositionIndex.chest, PositionIndex.rShoulder);
            AddSkeleton(PositionIndex.chest, PositionIndex.lShoulder);
            AddSkeleton(PositionIndex.hips, PositionIndex.rHip);
            AddSkeleton(PositionIndex.hips, PositionIndex.lHip);
        }

        // Set Inverse
         var forward = TriangleNormal(jointPoints[PositionIndex.hips.Int()].Transform.position, jointPoints[PositionIndex.lHip.Int()].Transform.position, jointPoints[PositionIndex.rHip.Int()].Transform.position);
        foreach (var jointPoint in jointPoints)
        {
            if (jointPoint != null)
            {
                if (jointPoint.Transform != null)
                {
                    jointPoint.InitRotation = jointPoint.Transform.rotation;
                }
                if (jointPoint.Child != null && jointPoint.Child.Transform != null && jointPoint.Child.Transform.position != null)
                {
                    jointPoint.Inverse = GetInverse(jointPoint, jointPoint.Child, forward);
                    jointPoint.InverseRotation = jointPoint.Inverse * jointPoint.InitRotation;
                }  
            }
        }

        // Hips Rotation
        var hips = jointPoints[PositionIndex.hips.Int()];
        initPosition = jointPoints[PositionIndex.hips.Int()].Transform.position;
        hips.Inverse = Quaternion.Inverse(Quaternion.LookRotation(forward));
        hips.InverseRotation = hips.Inverse * hips.InitRotation;

        // Head Rotation
        var head = jointPoints[PositionIndex.head.Int()];
        head.InitRotation = jointPoints[PositionIndex.head.Int()].Transform.rotation;
        var gaze = jointPoints[PositionIndex.Nose.Int()].Transform.position - jointPoints[PositionIndex.head.Int()].Transform.position;
        head.Inverse = Quaternion.Inverse(Quaternion.LookRotation(gaze));
        head.InverseRotation = head.Inverse * head.InitRotation;

        // Wrists Rotation
        //Left
        var lWrist = jointPoints[PositionIndex.lWrist.Int()];
        var lf = TriangleNormal(lWrist.Pos3D, jointPoints[PositionIndex.lPinky.Int()].Pos3D, jointPoints[PositionIndex.lThumb.Int()].Pos3D);
        lWrist.InitRotation = lWrist.Transform.rotation;
        lWrist.Inverse = Quaternion.Inverse(Quaternion.LookRotation(jointPoints[PositionIndex.lThumb.Int()].Transform.position - jointPoints[PositionIndex.lPinky.Int()].Transform.position, lf));
        lWrist.InverseRotation = lWrist.Inverse * lWrist.InitRotation;
        // Right
        var rWrist = jointPoints[PositionIndex.rWrist.Int()];
        var rf = TriangleNormal(rWrist.Pos3D, jointPoints[PositionIndex.rThumb.Int()].Pos3D, jointPoints[PositionIndex.rPinky.Int()].Pos3D);
        rWrist.InitRotation = jointPoints[PositionIndex.rWrist.Int()].Transform.rotation;
        rWrist.Inverse = Quaternion.Inverse(Quaternion.LookRotation(jointPoints[PositionIndex.rThumb.Int()].Transform.position - jointPoints[PositionIndex.rPinky.Int()].Transform.position, rf));
        rWrist.InverseRotation = rWrist.Inverse * rWrist.InitRotation;

        return JointPoints;

    }


    public void PoseUpdate()
    {
        // Movement and Rotatation of the Center
        var forward = TriangleNormal(jointPoints[PositionIndex.hips.Int()].Pos3D, jointPoints[PositionIndex.lHip.Int()].Pos3D, jointPoints[PositionIndex.rHip.Int()].Pos3D);
        
        jointPoints[PositionIndex.hips.Int()].Transform.position = jointPoints[PositionIndex.hips.Int()].Pos3D + initPosition - jointPositionOffset; // Took this out of the if-else for Vr

        jointPoints[PositionIndex.hips.Int()].Transform.rotation = Quaternion.LookRotation(forward) * jointPoints[PositionIndex.hips.Int()].InverseRotation;

        
        // Rotation of each of the Bones
        foreach (var jointPoint in jointPoints)
        {
            if (jointPoint.Parent != null)
            {
                var fv = jointPoint.Parent.Pos3D - jointPoint.Pos3D;
                jointPoint.Transform.rotation = Quaternion.LookRotation(jointPoint.Pos3D - jointPoint.Child.Pos3D, fv) * jointPoint.InverseRotation;
            }
            else if (jointPoint.Child != null)
            {
                jointPoint.Transform.rotation = Quaternion.LookRotation(jointPoint.Pos3D - jointPoint.Child.Pos3D, forward) * jointPoint.InverseRotation;
            }
        }

        foreach (var sk in Skeletons)
        {
            var s = sk.start;
            var e = sk.end;

            sk.Line.SetPosition(0, new Vector3(s.Pos3D.x * SkeletonScale + SkeletonX, s.Pos3D.y * SkeletonScale + SkeletonY, s.Pos3D.z * SkeletonScale + SkeletonZ));
            sk.Line.SetPosition(1, new Vector3(e.Pos3D.x * SkeletonScale + SkeletonX, e.Pos3D.y * SkeletonScale + SkeletonY, e.Pos3D.z * SkeletonScale + SkeletonZ));
        }
    }

    Vector3 TriangleNormal(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 d1 = a - b;
        Vector3 d2 = a - c;

        Vector3 dd = Vector3.Cross(d1, d2);
        dd.Normalize();

        return dd;
    }

    private Quaternion GetInverse(JointPoint p1, JointPoint p2, Vector3 forward)
    {
        return Quaternion.Inverse(Quaternion.LookRotation(p1.Transform.position - p2.Transform.position, forward));
    }

    ///<summary>
    /// Add skeleton from joint points
    ///</summary>
    /// <param name="s">position index</param>
    /// <param name="e">position index</param>
    private void AddSkeleton(PositionIndex s, PositionIndex e)
    {
        var sk = new Skeleton()
        {
            LineObject = new GameObject("Line"),
            start = jointPoints[s.Int()],
            end = jointPoints[e.Int()],
        };

        sk.Line = sk.LineObject.AddComponent<LineRenderer>();
        sk.Line.startWidth = 0.025f;
        sk.Line.endWidth = 0.005f;

        // define the number of vertex
        sk.Line.positionCount = 2;
        sk.Line.material = SkeletonMaterial;

        Skeletons.Add(sk);
    }

    private Vector3 GetCenter(GameObject obj)
    {
        Vector3 sumVector = Vector3.zero;

        foreach (Transform child in obj.transform)
        {          
            sumVector += child.position;        
        }

        Vector3 groupCenter = sumVector / obj.transform.childCount;
        return sumVector;
    }

    private void RunCalibration()
    {
        Instruction.SetActive(true);
        Debug.Log("Avatar calibration will begin in 5 seconds, please stand in T-pose!");
        // Removed vrRunning as an argument in the PoseCalibrationRoutine method
        StartCoroutine(PoseVisuallizer3D.PoseCalibrationRoutine(poseTDimensionsCalculated => {
                    ScaleAvatar(poseTDimensionsCalculated);
                    Debug.Log("Avatar calibration done!");
                    Instruction.SetActive(false);
                }));
    }


    ///<summary>
    /// Scale Avatar based on physical dimensions of user's body
    ///<summary/>
    private void ScaleAvatar(Vector3 bodyTDimensions)
    {
        Vector3 scaling;
        scaling.x = bodyTDimensions.x / avatarDimensions.x;
        scaling.y = bodyTDimensions.y / avatarDimensions.y;
        scaling.z = (scaling.x + scaling.y) / 2f;
        transform.localScale = scaling;
        jointPositionOffset.y = avatarCenter.y - avatarCenter.y * scaling.y;
        Debug.Log("Avatar scaling done");
    }

}
